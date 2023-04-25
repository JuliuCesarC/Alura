function getLinks(arrLinks) {
  return arrLinks.map((link) => Object.values(link).join());
}

async function checkStatus(urlLinks) {
  const arrStatus = await Promise.all(
    urlLinks.map(async (url) => {
      try {
        const res = await fetch(url);
        return res.status;
      } catch (error) {
        return errorHandling(error)       
      }
    })
  );
  return arrStatus;
}

function errorHandling(error){
  if(error.cause.code === "ENOTFOUND"){
    return "link fora do ar."
  }else{
    return "Ocorreu um erro"
  }
}

export default async function validateLinks(linkList) {
  const links = getLinks(linkList);
  const status = await checkStatus(links);

  return linkList.map((link, index)=>({
    ...link,
    status: status[index]
  }));
}
