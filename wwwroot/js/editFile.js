function edit(fileId) {
    let namefile = document.querySelector("#txtName");
    let modifiedAt = document.querySelector("#txtModify");
    let modifiedBy = document.querySelector("#txtModifyBy");
    let btnCreate = document.querySelector("#btnCreate");
    let btnEdit = document.querySelector("#btnEdit");
    let editButton = document.getElementById("btnEdit");

    $.ajax({
        url: "https://localhost:44321/api/MSTeams/" + fileId,
        dataType: "json",
        type: "GET",
        success: function (reponse) {
            btnCreate.style.display = "none";
            btnEdit.style.display = "block";
            namefile.value = reponse.name;
            modifiedAt.value = reponse.modified.substring(0, 10);
            modifiedBy.value = reponse.modify_By;



            editButton.onclick = () => {
                reponse.name = namefile.value;
                reponse.modified = modifiedAt.value;
                reponse.modify_By = modifiedBy.value;

                $.ajax({
                    url: "https://localhost:44321/api/MSTeams/" + reponse.id,
                    data: JSON.stringify(reponse),

                    contentType: "application/json",
                    type: "PUT",
                    success: function (reponse) {
                        alert("Success!");
                    }
                });
            }

        }
    });
}