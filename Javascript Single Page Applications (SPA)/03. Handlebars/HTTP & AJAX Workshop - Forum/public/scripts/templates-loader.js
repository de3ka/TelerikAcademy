function templateLoader(templateName) {
    return new Promise(function (resolve, reject) {
        $.ajax({
                method: 'GET',
                url: './scripts/templates/' + templateName + '.handlebars',
                contentType: 'text/html'
            })
            .done((data) => {
                let template = Handlebars.compile(data);
                resolve(template);
            })
            .fail(reject);
    });
}

export {
    templateLoader
};
