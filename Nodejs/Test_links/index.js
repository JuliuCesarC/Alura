import fs from "fs";
import chalk from "chalk";

function Log(data) {
  console.log(chalk.blue(data));
}
function errorHandling(err) {
  throw new Error(chalk.red(err));
}

function getFile_1(filePath) {
  fs.readFile(filePath, "utf-8", (err, data) => {
    if (err) errorHandling(err.code, "Arquivo não encontrado.");
    Log(chalk.blue(data));
  });
}
// getFile_1("./Text/Text.md");

function getFile_2(filePath) {
  fs.promises
    .readFile(filePath, "utf-8")
    .then((res) => {
      Log(res);
    })
    .catch(errorHandling);
}
getFile_2("./Text/Text.md");

