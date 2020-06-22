//Example of how to use promises
//  https://www.youtube.com/watch?v=s6SH72uAn3Q
//  https://www.youtube.com/watch?v=104J7_HyaG4
//Another method for firing callback can be found at https://api.jquery.com/jQuery.Callbacks/


//List of functions
let cleanRoom = function () {
    return new Promise(function (resolve, reject) {
        resolve('Cleaned the room.');
    });
}


let removeGarbage = function (message) {
    return new Promise(function (resolve, reject) {
        resolve(message + ' Removed garbage.');
    });
}


let winIcecream = function (message) {
    return new Promise(function (resolve, reject) {
        resolve(message + ' Won icecream.');
    });
}




//Synchronous call to multiple functions
cleanRoom().then(function (result) {
    return removeGarbage(result);
}).then(function (result) {
    return winIcecream(result);
}).then(function (result) {
    console.log('FINISHED: ' + result);
});
