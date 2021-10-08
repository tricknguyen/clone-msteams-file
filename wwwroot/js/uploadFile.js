function fileupload(filename) {
    var inoutfile = document.getElementById(filename);
    var files = inoutfile.files;

    var fdata = new FormData();
    for (let i = 0; i != files.length; i++) {
        fdata.append("files", files[i]);
    }

    $.ajax({
        url: "https://localhost:44321/api/MSTeams",
        data: fdata,
        processData: false,
        contentType: false,
        type: "POST",
        success: function (reponse) {
            let date = reponse.modified.substring(0, 10);
            console.log(reponse);
            alert("File Upload Successfully!");
            $("#tbData").append(`
            <div id="roww${reponse.id}">
                <div class="row" id="row-2">
                <div class="col-1 space"></div>
                <div class="col-1 icon">
                <img src="https://spoprod-a.akamaihd.net/files/fabric/assets/item-types/20/folder.svg?v6"
                        width="16px" height="16px">
            </div>
            <div class="col-3 name">
            <span class="flex-box" >
              <span class="name-text" onclick="edit(${reponse.id})">${reponse.name}</span>
            </span>
            </div>
          <div class="col-2 modify">
            <span class="flex-box">
              <span>${date}</span>
            </span>
          </div>
          <div class="col-2 modify">
            <span class="flex-box">
              <span>${reponse.modify_By}</span>
            </span>
          </div>
          <div class="col option">
            <span class="flex-box">
              <span onclick="deleterow(${reponse.id})">Delete</span>
            </span>
          </div>
        </div>
    </div>`);
        }

    });
}