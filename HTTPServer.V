import net.http
import os

fn main() {
    mut server := http.Server{
        port: 8080
        handle: handle_request
    }
    server.serve() or { panic(err) }
}

fn handle_request(req http.Request) http.Response {
    if req.method == .get {
        file_path := os.join_path('static', req.url.path)
        if os.exists(file_path) {
            return http.Response{
                status: .ok
                body: os.read_file(file_path) or { 'File not found' }
                headers: {
                    'Content-Type': 'text/html'
                }
            }
        }
    }
    return http.Response{
        status: .not_found
        body: '404 Not Found'
    }
}
