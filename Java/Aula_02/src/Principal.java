import com.cesar.aula02.bingeWatch.TotalTimeCalculator;
import com.cesar.aula02.model.Movie;
import com.cesar.aula02.model.Series;

import java.text.DecimalFormat;

public class Principal {
  public static void main(String[] args) {
    DecimalFormat df = new DecimalFormat("#.0");
    
    Movie newFilm = new Movie();
    newFilm.setName("Interestelar");
    newFilm.setReleaseDate(2014);
    newFilm.setDuration(169);
    newFilm.showInfo();
    System.out.println("Duração filme em minutos: "+ newFilm.getDuration());
    
    newFilm.rate(8);
    newFilm.rate(7.5);
    newFilm.rate(8.2);
    System.out.println("Avaliação do filme: "+df.format(newFilm.average()));

    Series tvShow = new Series();
    tvShow.setName("Rick and Morty");
    tvShow.setMinutesEpisode(22);
    tvShow.setCompleteSeries(false);
    tvShow.setEpisodesPerSeason(10);
    tvShow.setNumberOfSeasons(6);
    System.out.println("\nDuração da serie: "+ (tvShow.getDuration() / 60)+ " horas");
    
    Movie matrix = new Movie();
    matrix.setName("Matrix");
    matrix.setReleaseDate(1999);
    matrix.setDuration(136);
    
    TotalTimeCalculator calculator = new TotalTimeCalculator();
    calculator.include(newFilm);
    calculator.include(matrix);
    calculator.include(tvShow);

    System.out.println("\nTempo total para maratonar: "+df.format(calculator.getTotalTime() / 60.0)+" horas");
  }
}