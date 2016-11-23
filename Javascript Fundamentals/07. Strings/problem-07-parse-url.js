function parseURL(args) {
    var url=String(args[0]);

    var protocol = '',
        server = '',
        resource = '';

    protocol = url.substr(0, url.indexOf("://"));
    url = url.substr(url.indexOf("://") + 3);
    server = url.substr(0, url.indexOf("/"));
    resource = url.substr(url.indexOf("/"));

    console.log('protocol: ' + protocol + "\n" + 'server: ' + server + "\n" + 'resource: ' + resource);
}
