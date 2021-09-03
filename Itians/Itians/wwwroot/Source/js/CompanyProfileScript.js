window.addEventListener("scroll", function (e) {
  if (window.scrollY >= 350 && document.body.clientWidth >= 1000) {
    document.querySelector(".company-information").style.position = "fixed";
    document.querySelector(".company-information").style.top = "10px";
    document.querySelector(".company-information").style.width = "25%";
    //document.querySelector(".jobs").style.marginLeft = "420px";
  } else {
    document.querySelector(".company-information").style.position = "static";
    document.querySelector(".company-information").style.width = "auto";
  }
  let goUp = document.querySelector("#goUp");
  if (window.scrollY > 400) {
    goUp.classList.add("goUpShow");
  } else {
    goUp.classList.remove("goUpShow");
  }
});
