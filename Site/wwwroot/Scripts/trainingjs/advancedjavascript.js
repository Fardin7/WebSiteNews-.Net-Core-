//var n = 20;
//firstloop:for (var i =3; i < n; i++) {
//    var flag = true;
//    for (var j = 2; j < i; j++) {
//        if (i % j == 0) {
//            continue firstloop;
//        }

//    }
    
//        alert(i);

//}

//var car = {

//    color: "red",
//    model: "porche",
//    price: 125000,
//    speed: 320,
//    move: function () {

//        console.log(`car is moving with ${this.speed}`);
//    }

//}
////var carobject = car;
////carobject.color = "green";
////car.croop = true;

////console.log(car.croop);
//// function object
//this.oldcar = "bmw";
//var carobject = function () {
//    this.color = "red",
//        this.speed = 350,
//        this.move = function () {

//            console.log(`car is moving wiht ${this.speed} and ${this.oldcar}`)
//        }
//    this.sayhello = function () {

//        console.log("hi")
//    }


//}

//var outermethod = (name, speed) => {

//    console.log(this.color + " " + name + " is " + speed
//    );
//}
//var car1 = new carobject();
////car1.move.call(this);
//var arr = ["car", "350"];
////var boundedfunction = outermethod.call(car1, "car", "620");
////boundedfunction("car","350")
////carobject.prototype.name = "porch2018";



////console.dir(car1)
////var car2 = new carobject();
////car2.color = "green";
////console.log(car2.name);
////console.dir(car2);
//////car2.price = 25;
////console.dir(car2);

////var carinfo = function () {

////    console.log("this is porche")
////}

////var car3 = new carobject(carinfo());
////car3.sayhello;
////
////factory pattern and constructor pattern with prototype and dynamic prototype pattern in ES6


//var humanFactory = function (name,heigh,i) {
//    this.i = i;
//    this.name = name;
//    this.heigh = heigh;
//    if (typeof this.display !== 'function') {
//        this.i = this.i + 1;
//        humanFactory.prototype.display = function () {

//            console.log(`this is ${this.name} whis ${this.heigh} tall ${this.i}`);
//        }

//    }
   
//}



//var person1 = new humanFactory("fardin",170,0);
//var person2 = new humanFactory("hemin", 180, person1.i);
////person1.name = "fardin";
////person1.heigh = 170;
////console.log(person1.hasOwnProperty('name'));
//console.log(person1.display());
//console.log(person2.display());