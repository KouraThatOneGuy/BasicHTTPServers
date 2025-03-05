library(httpuv)

# Define the server
server <- startServer("0.0.0.0", 8080, list(
  call = function(req) {
    if (req$REQUEST_METHOD == "GET") {
      # Serve static HTML files
      file_path <- paste0("www", req$PATH_INFO)
      if (file.exists(file_path)) {
        res <- list(
          status = 200,
          headers = list("Content-Type" = "text/html"),
          body = readLines(file_path)
        )
      } else {
        res <- list(
          status = 404,
          headers = list("Content-Type" = "text/plain"),
          body = "404 Not Found"
        )
      }
      return(res)
    }
  }
))

# Keep the server running
cat("Server is running at http://0.0.0.0:8080\n")
while (TRUE) {
  Sys.sleep(1)
}
