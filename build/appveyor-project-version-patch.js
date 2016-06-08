var jsonfile = require('jsonfile');
var semver = require('semver');

var file = '../src/twee.thetvdbapi/project.json';
var buildVersion = process.env.APPVEYOR_BUILD_VERSION;
var semversion  = semver.valid(buildVersion)

jsonfile.readFile(file, function (err, project) {
	project.version = semversion;
	jsonfile.writeFile(file, project, {spaces: 2}, function(err) {
		console.error(err);
	});
});
process.exit()