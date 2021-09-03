window.addEventListener("scroll", function (e) {
  let goUp = document.querySelector("#goUp");
  if (window.scrollY > 400) {
    goUp.classList.add("goUpShow");
  } else {
    goUp.classList.remove("goUpShow");
  }
});
