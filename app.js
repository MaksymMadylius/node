var http = require('http');

http.createServer((req, res) => {
    
    res.writeHead(200);
    res.end("Hello world");

}).listen(777, '127.0.0.1');
