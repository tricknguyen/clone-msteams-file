function deleterow(id) {
    $.ajax({
        url: "https://localhost:44321/api/MSTeams/" + id,
        type: "DELETE",
        success: function (reponse) {
            alert("Success!");
            $(`#roww${id}`).remove();

        }
    });
}
