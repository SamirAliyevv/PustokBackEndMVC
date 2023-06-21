$(document).on("click", ".basket-add-btn", function (e) {
    e.preventDefault();
    let url = $(this).attr("href");
    fetch(url).then(response => {
        if (!response.ok) {
            alert("xeta bas verdi")
        }
        else return response.text();
    }).then(data => {
        $('#basketCard').html(data)
    })
})


