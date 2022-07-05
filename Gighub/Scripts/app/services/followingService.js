var FollowingService = function () {

    var createFollowing = function (followeeId, done, fail) {
        alert("createFollowing " + followeeId);
        $.post("/api/followings", { FolloweeId: followeeId })
            .done(done)
            .fail(fail);

    };

    var deleteFollowing = function (followeeId, done, fail) {
        $.ajax({
                url: "/api/followings/" + followeeId,
                method: "DELETE"
            })
            .done(done)
            .fail(fail);
    };

    return {
        createFollowing: createFollowing,
        deleteFollowing: deleteFollowing
    }
}();