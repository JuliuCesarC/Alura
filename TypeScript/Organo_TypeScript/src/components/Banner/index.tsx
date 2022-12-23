import React from "react";
import "./banner.css";

interface BannerProps {
  imageUrl: string;
  altText?: string;
  // O texto alternativo é extremamente indicado para as tags img, mas não obrigatório, com isso "tipamos" ele como opcional 'altText?: ...' 
}

export default function Banner({ imageUrl, altText }: BannerProps) {
  return (
    <header className="banner">
      <img className="banner_img" src={imageUrl} alt={altText} />
    </header>
  );
}
