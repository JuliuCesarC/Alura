import getFile_4 from "./index.js";

const pathArgs = process.argv;

async function showLinks(path){
  const res = await getFile_4(path[2])
  console.log(res);
}

showLinks(pathArgs)