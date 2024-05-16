// Loop through each list item within the unordered list with ID "addresses-list"
$("#addresses-list li").click(function () {
  var text = $(this).text().trim();
  console.log(text);
  // Retrieve the text content of the current list item and log it to the console
  document.getElementById("saved-addresses").innerText = text;
});

// Loop through each list item within the unordered list with ID "addresses-list"
$("#countries-list li").click(function () {
  var text = $(this).text().trim();
  console.log(text);
  // Retrieve the text content of the current list item and log it to the console
  document.getElementById("saved-countries").innerText = text;
});
