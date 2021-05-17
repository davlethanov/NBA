export interface Game {
    id: string,
    awayTeamId: string,
    awayTeamName: string,
    homeTeamId: string,
    homeTeamName: string,
    date: Date,
    awayTeamScore?: number,
    homeTeamScore?: number
}
