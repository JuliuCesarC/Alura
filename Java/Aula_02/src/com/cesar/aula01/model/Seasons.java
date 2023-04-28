package com.cesar.aula01.model;

public class Seasons extends Title {
  private int numberOfSeasons;
  private int episodesPerSeason;
  private boolean completeSeries;
  private int minutesEpisode;

  public int getNumberOfSeasons() {
    return numberOfSeasons;
  }

  public void setNumberOfSeasons(int numberOfSeasons) {
    this.numberOfSeasons = numberOfSeasons;
  }

  public int getEpisodesPerSeason() {
    return episodesPerSeason;
  }

  public void setEpisodesPerSeason(int episodesPerSeason) {
    this.episodesPerSeason = episodesPerSeason;
  }

  public boolean isCompleteSeries() {
    return completeSeries;
  }

  public void setCompleteSeries(boolean completeSeries) {
    this.completeSeries = completeSeries;
  }

  public int getMinutesEpisode() {
    return minutesEpisode;
  }

  public void setMinutesEpisode(int minutesEpisode) {
    this.minutesEpisode = minutesEpisode;
  }
}
