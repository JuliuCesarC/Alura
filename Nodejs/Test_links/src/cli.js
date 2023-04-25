import chalk from "chalk";
import getFile_4 from "./index.js";
import validateLinks from "./httpValidate.js";
import fs from "fs";

const pathArgs = process.argv;

async function showLinks(validate, response, file) {
  if (validate) {
    console.log(
      `${chalk.bgGray("Lista validada")}:`,
      await validateLinks(response)
    );
  } else {
    console.log(
      `${chalk.bgGray("Lista de links no arquivo")} ${chalk.cyan(file)}:`,
      response
    );
  }
}

async function linksProcessing(args) {
  const path = args[2];
  const validate = args[3] === "--validate"

  try {
    fs.lstatSync(path);
  } catch (error) {
    if (error.code === "ENOENT") {
      console.log(chalk.yellow("arquivo ou diretório não existe"));
      return;
    }
  }

  if (fs.lstatSync(path).isFile()) {
    const res = await getFile_4(path);
    showLinks(validate, res, path.match(/\/[\w]*\.[\w]{2}$/));
  } else if (fs.lstatSync(path).isDirectory()) {
    const folder = await fs.promises.readdir(path);

    folder.forEach(async (file) => {
      const res = await getFile_4(path + "/" + file);
      showLinks(validate, res, file);
    });
  }
}

linksProcessing(pathArgs);
