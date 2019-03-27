var count = 0;

function clickCount() {
    count = count + 1;
    postMessage(count);
    console.log(count);
};

clickCount();
