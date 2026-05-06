function calculate() {

  // Read values from DOM
  let x = ParseFloat(document.getElementById("num1").value );
  let y = parseFloat( document.getElementById("num2").value );
  let operator = document.getElementById("operator").value;

  let result;

  // Switch Case
  switch (operator) {
    case "+":
      result = x + y;
      break;

    case "-":
      result = x - y;
      break;

    case "*":
      result = x * y;
      break;

    case "/":
      result =   num1 / num2 ;
      break;

    default:
      result = "Invalid Operation";
  }

  // Display result
  document.getElementById("result").innerText =
    "Result: " + result;
}
