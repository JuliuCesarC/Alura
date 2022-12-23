import "./Footer.css"

export default function Footer(){

  return(
    <div className="container_footer">
      <img src="img/fundo.png" alt="fundo" className="bg_footer"/>
        <div className="social">
          <a href=""><img src="img/fb.png" alt="link Facebook" /></a>
          <a href=""><img src="img/tw.png" alt="link Twitter" /></a>
          <a href=""><img src="img/ig.png" alt="link Instagram" /></a>
        </div>
        <div className="logo_footer">
          <img src="img/logo.png" alt="logo site" />
        </div>
        <div className="owner">By Alura.</div>
    </div>
  )
}