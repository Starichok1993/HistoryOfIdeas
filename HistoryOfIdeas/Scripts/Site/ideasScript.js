(function($, ko) {

    $.support.cors = true;

    //View Model
    function ideasViewModel(model) {
        var self = this;

        //DATA
        if (model.length == 0) {
            self.ideas = ko.observableArray();
        } else {
            self.ideas = ko.observableArray(model);
        }
        self.newIdea = ko.observable("");


        //help functions
        function addIdeaToList(data) {
            self.ideas.unshift(data);
            self.newIdea = "";
        }

        function serverError(error) {
            alert("Server error");
        }

        //event handler
        self.addIdea = function() {
            if (self.newIdea() === "") {
                return;
            }

            //$.ajax({
            //    url: "/api/ideas",
            //    type: "Post",
            //    dataType: "json",
            //    data: self.newIdea(),
            //    success: addIdeaToList,
            //    error: function (err) {
            //        alert("Server error");
            //        console.log(err);
            //    }
            //});
            $.post("/api/ideas", self.newIdea(), addIdeaToList).fail(serverError);
        };

        self.deleteIdea = function(idea) {
            if (idea != null) {
                $.ajax({
                    url: "api/ideas",
                    dataType: "json",
                    type: "Delete",
                    data: idea.Id,
                    error: serverError
                });
            }
        };

        return self;
    }


    var ideasFromServer;

    $.ajax({
        url: "/api/ideas",
        dataType: "json",
        async: false,
        cache: false,
        type: "Get",
        success: function (data) {
            if (data === null) {
                data = new Array();
            }
            ideasFromServer = data;
        },
        error: function() {
            alert("Server error");
        }

    });

    var viewModel = ideasViewModel(ideasFromServer);
    ko.applyBindings(viewModel);


})(jQuery, ko);