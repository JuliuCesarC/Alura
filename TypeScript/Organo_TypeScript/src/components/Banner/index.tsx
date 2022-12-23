import React from "react";
import "./banner.css";

interface BannerProps {
  imageUrl: string;
  altText?: string;
}

export default function Banner({ imageUrl, altText }: BannerProps) {
  return (
    <header className="banner">
      <img className="banner_img" src={imageUrl} alt={altText} />
    </header>
  );
}
