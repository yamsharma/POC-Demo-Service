export class Api {
  private static readonly apiUrl = 'https://localhost:5001/api/';

  // FN APIs
  public static readonly FNInfoUrl = `${Api.apiUrl}ForeignNationals`;
  public static readonly FNCaseNotesUrl = `${Api.FNInfoUrl}/GetCaseNotes`;

  // Case Notes APIs
  public static readonly CaseNotesUrl = `${Api.apiUrl}FNCaseNotes`;
  public static readonly FNCaseNotesUrl2 = `${Api.CaseNotesUrl}/GetAllByForeignNationalId`;
}
