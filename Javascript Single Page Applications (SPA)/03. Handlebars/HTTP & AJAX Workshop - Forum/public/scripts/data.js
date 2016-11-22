/*eslint-env es6*/

var data = (function () {
    const USERNAME_STORAGE_KEY = 'username-key';

    // start users
    function userLogin(user) {
        localStorage.setItem(USERNAME_STORAGE_KEY, user);
        return Promise.resolve(user);
    }

    function userLogout() {
        localStorage.removeItem(USERNAME_STORAGE_KEY);
        return Promise.resolve();
    }

    function userGetCurrent() {
        return Promise.resolve(localStorage.getItem(USERNAME_STORAGE_KEY));
    }
    // end users

    // start threads
    function threadsGet() {
        return new Promise((resolve, reject) => {
            $.getJSON('api/threads')
                .done(data => {
                    //console.log(data);
                    resolve(data)
                })
                .fail(reject);
        });
    }

    function threadsAdd(title) {
        return new Promise((resolve, reject) => {
            userGetCurrent()
                .then(function (username) {
                    //console.log(username);
                    let thread = {
                        title, username
                    };

                    $.ajax({
                            type: 'POST',
                            url: 'api/threads',
                            data: JSON.stringify(thread),
                            contentType: 'application/json'
                        }).done(data => {
                            //console.log(data);
                            resolve(data)
                        })
                        .fail(err => reject(err));
                });
        });
    }

    function threadById(id) {
        return new Promise((resolve, reject) => {
            $.getJSON('api/threads/' + id)
                .done(resolve)
                .fail(reject);
        });
    }

    function threadsAddMessage(threadId, content) {
        userGetCurrent()
            .then(function (username) {
                let message = {
                    username: username,
                    content: content
                };
                //console.log(username);
                $.ajax({
                        method: 'POST',
                        url: 'api/threads/' + threadId + '/messages',
                        contentType: 'application/json',
                        data: JSON.stringify(message)
                    })
                    .done()
                    .fail();
            });

    }
    // end threads

    // start gallery
    function galleryGet() {
        const REDDIT_URL = `https://www.reddit.com/r/aww.json?jsonp=?`;
        return new Promise((resolve, reject) => {
            $.getJSON(REDDIT_URL)
                .done(resolve)
                .fail(reject);
        });
    }
    // end gallery

    return {
        users: {
            login: userLogin,
            logout: userLogout,
            current: userGetCurrent
        },
        threads: {
            get: threadsGet,
            add: threadsAdd,
            getById: threadById,
            addMessage: threadsAddMessage
        },
        gallery: {
            get: galleryGet
        }
    };
})();

export {
    data
};
