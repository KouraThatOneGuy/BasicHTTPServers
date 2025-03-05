#include <iostream>
#include <string>
#include <fstream>
#include <sstream>
#include <boost/asio.hpp>

using boost::asio::ip::tcp;

const std::string get_file_content(const std::string& path) {
    std::ifstream file(path);
    if (!file) return "404 Not Found";
    std::stringstream buffer;
    buffer << file.rdbuf();
    return buffer.str();
}

int main() {
    try {
        boost::asio::io_context io_context;
        tcp::acceptor acceptor(io_context, tcp::endpoint(tcp::v4(), 8080));

        while (true) {
            tcp::socket socket(io_context);
            acceptor.accept(socket);

            std::array<char, 1024> buffer;
            socket.read_some(boost::asio::buffer(buffer));

            std::string request(buffer.data());
            std::string method = request.substr(0, request.find(' '));
            std::string path = request.substr(request.find(' ') + 1);
            path = path.substr(0, path.find(' '));

            if (method == "GET") {
                std::string content = get_file_content(path.substr(1));
                std::string response = "HTTP/1.1 200 OK\r\nContent-Length: " + std::to_string(content.size()) + "\r\n\r\n" + content;
                boost::asio::write(socket, boost::asio::buffer(response));
            }
        }
    } catch (std::exception& e) {
        std::cerr << "Exception: " << e.what() << "\n";
    }
    return 0;
}
