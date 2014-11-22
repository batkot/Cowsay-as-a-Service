
setInterval(
    function () {
        getCow(function (cow) {
            display(cow)
        }
        )
    }, 10000);

function getCow(display)
{
    $.ajax(
        {
            type: "POST",
            url: "api/cowsay",
            contentType: "application/json",
            data: "",
            success: function(cow) 
            {
                display(cow);
            }
        })
}

function display(cow)
{
    $("#cow").html(cow);
}