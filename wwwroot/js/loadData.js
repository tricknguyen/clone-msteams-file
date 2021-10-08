var a = []

$(document).ready(function() {
    let table = document.querySelector("#tbData");
    table.innerHTML = "";
    $.ajax({
       url: "https://localhost:44321/api/MSTeams",
       dataType: "json",
       type: "GET",
        success: function (reponse) {
          for (i in reponse) {
              a.push(reponse[i]);
          }
          handleData();
                
       }
    });
    function handleData() {
        a.forEach(element => {
            let date = element.modified.substring(0, 10);
            table.innerHTML += `
    <div id="roww${element.id}">
            <div class="row" id="row-2">
                <div class="col-1 space"></div>
                <div class="col-1 icon">
            <img src="https://spoprod-a.akamaihd.net/files/fabric/assets/item-types/20/folder.svg?v6"
                        width="16px" height="16px">
            </div>
            <div class="col-3 name">
            <span class="flex-box" >
              <span class="name-text" onclick="edit(${element.id})">${element.name}</span>
            </span>
            </div>
          <div class="col-2 modify">
            <span class="flex-box">
              <span>${date}</span>
            </span>
          </div>
          <div class="col-2 modify">
            <span class="flex-box">
              <span>${element.modify_By}</span>
            </span>
          </div>
          <div class="col option">
            <span class="flex-box">
              <span onclick="deleterow(${element.id})">Delete</span>
            </span>
          </div>
        </div>
    </div>
      `;
        })
    }
  
});








