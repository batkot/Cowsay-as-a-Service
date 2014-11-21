var seconds = $("#countdown").data("countdown-remaining");

ts = TimeSpan.FromSeconds(seconds);

$(document).ready(
    function () {
        showTime();
        setInterval(
            function () { countdown() },
            1000);
    });

function countdown()
{
    ts.subtractSeconds(1);
    showTime();
}

function showTime()
{
    $("#countdown-seconds").html(ts.seconds());
    $("#countdown-minutes").html(ts.minutes());
    $("#countdown-hours").html(ts.hours() + ts.days()*24);
}