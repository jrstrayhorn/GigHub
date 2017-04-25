
var FollowingsController = function () {

    var init = function () {
        $(".js-toggle-following").click(toggleFollowing);
    };

    var toggleFollowing = function (e) {
        var button = $(e.target);
        if (button.hasClass("btn-default")) {
            $.post("/api/followings", { artistId: button.attr("data-artist-id") })
            .done(function () {
                button
                    .removeClass("btn-default")
                    .addClass("btn-info")
                    .text("Following");
            })
            .fail(function () {
                // can use toast later
                alert("Something failed!");
            });
        } else {
            $.ajax({
                url: "/api/followings/" + button.attr("data-artist-id"),
                method: "DELETE"
            })
            .done(function () {
                button
                    .removeClass("btn-info")
                    .addClass("btn-default")
                    .text("Follow?");
            })
            .fail(function () {
                alert("Something failed!");
            });
        }
    };

    return {
        init: init
    }

}();