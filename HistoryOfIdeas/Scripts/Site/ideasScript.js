(function($, ko) {

    $.support.cors = true;

    //View Model
    function ideasViewModel(model) {
        var self = this;

        //DATA
        if (model.length == 0) {
            self.ideas = ko.observableArray();
        } else {
            for (var item in model) {
                model[item].isEditing = ko.observable(false);
                model[item].Text = ko.observable(model[item].Text);
            }
            self.ideas = ko.observableArray(model);
        }

        self.newIdea = ko.observable("");


        //help functions
        function addIdeaToList(data) {
            data.isEditing = ko.observable(false);
            data.Text = ko.observable(data.Text);
            self.ideas.unshift(data);
            self.newIdea("");
        }

        function serverError(error) {
            alert("Server error" + error);
        }

        function putRequestToServer(idea) {
            $.ajax({
                url: "api/ideas/" + idea.Id,
                dataType: "json",
                type: "Put",
                data: "=" + idea.Text(),
                error: serverError
            });
        }


        //event handler
        self.addIdea = function() {
            if (self.newIdea() === "") {
                return;
            }

            $.ajax({
                url: "/api/ideas",
                type: "Post",
                data: "=" + self.newIdea(),
                success: addIdeaToList,
                error: function (err) {
                    alert("Server error");
                    console.log(err);
                }
            });
          //  $.post("/api/ideas", {
          //      "newIdea" : self.newIdea()
       // }, addIdeaToList).fail(serverError);
        };

        self.deleteIdea = function(idea) {
            if (idea != null) {

                if (confirm("A your sure?")) {
                    $.ajax({
                        url: "api/ideas",
                        dataType: "json",
                        type: "Delete",
                        data: "=" + idea.Id,
                        success: function() {
                            self.ideas.remove(idea);
                        },
                        error: serverError
                    });
                }
            }
        };

        self.editIdea = function(idea) {
            if (idea != null) {
                putRequestToServer(idea);
            }
            return;
        };

        self.enableEdit = function(idea) {
            if (idea != null) {
                idea.isEditing(true);
            }
            return;
        };

        self.disableEdit = function (idea) {
            if (idea != null) {
                idea.isEditing(false);
            }
            return;
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