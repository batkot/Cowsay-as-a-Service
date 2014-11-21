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
    $("#countdown-seconds").html(pad(ts.seconds()));
    $("#countdown-minutes").html(pad(ts.minutes()));
    $("#countdown-hours").html(pad(ts.hours() + ts.days()*24));
}

function pad(number)
{
    return ("0" + number).slice(-2);
}