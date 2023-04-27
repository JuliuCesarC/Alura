public class Movie {
  String name;
  int releaseDate;
  double rating;
  int totalRating;
  int numberRating;
  int duration;
  void showInfo(){
    System.out.println("Nome do filme: "+name);
    System.out.println("Ano de lançamento: "+releaseDate);
  }
  void rate(double grade){
    rating += grade;
    totalRating ++;
  }
}
