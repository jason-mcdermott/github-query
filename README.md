# GithubQuery
A Github REST API v3 viewer made with .NET Core.

## Project Notes
```

- If you have a Github API access token, you can add to the appsettings.json file. otherwise, calls will be made without bearer
  token (and may be throttled).

- Some sample endpoints to try out:

  // all ramda organization repos
  https://localhost:44354/api/ramda/repos

  // all ramda organization repos (count)
  https://localhost:44354/api/ramda/repos/count

  // all ramda organization repos paginated
  https://localhost:44354/api/ramda/repos/page/1?resultsperpage=5

  // all ramda org / ramda repo PR's paginated and where state is closed (supports 'open', 'closed', 'all'. 'all' is the default)
  https://localhost:44354/api/ramda/ramda/pulls/page/1?resultsperpage=5&state=closed

  // Caution: ALL ramda org PR's (this takes a while to complete, but it gets cached so second time not so much).
  https://localhost:44354/api/ramda/pulls

  // Caution: ALL ramda org PR's count (this takes a while to complete, but it gets cached so second time not so much).
  https://localhost:44354/api/ramda/pulls/count

  // pull ramdangular PR's where updated_at between this range: 2014-12-02T12:04:42Z and 2014-12-02T16:04:42Z
  https://localhost:44354/api/ramda/ramdangular/pulls/daterange/count?start=2014-12-02T12:04:42Z&end=2014-12-02T16:04:42Z&filter=updated_at


- I leveraged existing code for the GithubQuery.Attributes.ExceptionFilter and the GithubQuery.Extensions.LinkHeaderExtensions (which saved
  me a lot of time and tears!). Links to sources are in the code files.
