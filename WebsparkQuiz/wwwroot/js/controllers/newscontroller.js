var NewsController = function ($,newsDataService, handleBars) {
    var currentDisplayElement;
    var currentTemplateId;
    var displayNews = function (data) {
        var source = document.getElementById(currentTemplateId).innerHTML;
        var template = handleBars.compile(source);
        var htmlTemplate = "";
        for (var i = 0; i < data.length; i++) {
            htmlTemplate += template(data[i]);
        }
        $(currentDisplayElement).html(htmlTemplate);
    };

    var displayError = function (ex) {
        alert("Failed to get data " + ex);
    };

    var initData = function (templateId, displayElement) {
        currentDisplayElement = displayElement;
        currentTemplateId = templateId;
        newsDataService.getAllNews(displayNews, displayError);
    };

    return {
        initData: initData
    };
}(jQuery,NewsDataService, Handlebars);