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
// getFile_2("./Text/Text.md");

async function getFile_3(filePath) {
  try {
    const text = await fs.promises.readFile(filePath, "utf-8");
    Log(text);
  } catch (err) {
    errorHandling(err);
  }
}
// getFile_3("./Text/Textt.md");

function getLinks(text) {
  const regex = /\[([^[\]]*)\]\((https?:\/\/[^)]*)\)/gm;
  const match = [...text.matchAll(regex)];
  const res = match.map((arr) => ({ [arr[1]]: arr[2] }));
  return res.length > 1 ? res : "Nenhum link encontrado";
}

export default async function getFile_4(filePath) {
  try {
    const text = await fs.promises.readFile(filePath, "utf-8");
    return getLinks(text);
  } catch (err) {
    errorHandling(err);
  }
}
// getFile_4("./Text/Text.md");
