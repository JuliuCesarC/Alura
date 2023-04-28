import com.cesar.aula01.model.Movie;

public class Principal {
  public static void main(String[] args) {
    Movie newFilm = new Movie();
    newFilm.setName("Interestelar");
    newFilm.setReleaseDate(2014);
    newFilm.setDuration(140);
    
    newFilm.showInfo();
    newFilm.rate(8);
    newFilm.rate(7.5);
    newFilm.rate(8.2);
    System.out.println(newFilm.average());
  }
}