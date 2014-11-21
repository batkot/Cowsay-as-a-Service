function counter(onFinishCallback) {
    var countdownElement = $(".countdown-container");

    var timer;

    var ts = TimeSpan.FromSeconds(countdownElement.data("countdown-remaining"));

    $(document).ready(
        function () {
            updateTime();
            timer = setInterval(
                        function () { countdown() },
                        1000);
        });

    function countdown() {
        if (ts.equals(TimeSpan.FromSeconds(0))) {
            finishCountdown();
            return;
        }

        ts.subtractSeconds(1);
        updateTime();
    }

    function updateTime() {
        $("#countdown-seconds").html(format(ts.seconds()));
        $("#countdown-minutes").html(format(ts.minutes()));
        $("#countdown-hours").html(format(ts.hours() + ts.days() * 24));
    }

    function format(number) {
        return ("0" + number).slice(-2);
    }

    function finishCountdown() {
        clearInterval(timer);

        if (onFinishCallback)
            onFinishCallback();
    }
}