//import * from main;
import { data } from '/scripts/data.js';
import { templateLoader } from '/scripts/templates-loader.js';

let router = (function () {
    let navigo;

    function init() {
        navigo = new Navigo(null, false);

        navigo
            .on({
                '/': function () {
                    $('#content').html('');
                },
                '/threads': function () {
                    Promise.all([data.threads.get(), templateLoader('threads-template')])
                        .then(([data, template]) => {
                            let html = template(data);
                            $('#content').html(html);
                            //$('#messages').html('');
                        })
                        .catch(console.log);
                },
                '/threads/:id': function (params) {
                    Promise.all([data.threads.getById(params.id), templateLoader('messages-template')])
                        .then(([data, template]) => {
                            //console.log(data);
                            let html = template(data);
                            html = $('#content').html() + html;
                            $('#content').html(html);
                        })
                        .catch(console.log);
                },
                '/gallery': function () {
                    Promise.all([data.gallery.get(), templateLoader('gallery-template')])
                        .then(([data, template]) => {
                            let html = template(data);
                            $('#content').html(html);
                        })
                        .catch(console.log)
                }
            })
            .resolve();
    }

    function redirect(destination) {
        navigo.navigate(destination);
    }

    return {
        init, redirect
    }
}());

export {
    router
};
