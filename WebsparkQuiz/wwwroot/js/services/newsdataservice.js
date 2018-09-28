var NewsDataService = function () {
    var getDataService = function (url, done, fail) {
        $.ajax({
                url: url,
                method: "GET"
            })
            .done(done)
            .fail(fail);
    };

    var getAllNews = function (done, fail) {
        getDataService("/api/news", done, fail);
    };

    var getNewsById = function (newsId, done, fail) {
        getDataService("/api/news/" + newsId, done, fail);
    };

    return {
        getAllNews: getAllNews,
        getNewsById: getNewsById
    };
}();