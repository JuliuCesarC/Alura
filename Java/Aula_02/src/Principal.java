public class Principal {
  public static void main(String[] args) {
    Movie newFilm = new Movie();
    newFilm.name = "Interestelar";
    newFilm.releaseDate = 2014;
    newFilm.duration = 140;
    
    newFilm.showInfo();
  }
}