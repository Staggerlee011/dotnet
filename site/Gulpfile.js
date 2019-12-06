/// <binding BeforeBuild='default' />
/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var rename = require('gulp-rename');
var staticFiles = [
    './node_modules/jQuery/dist/**/*.js',
    './node_modules/bootstrap/dist/**/*.{js,css}',
    './node_modules/jquery-validation/dist/*.js',
    './node_modules/jquery-validation-unobtrusive/dist/*.js'
];

gulp.task('npmModules', function () {
    // the base option sets the relative root for the set of files,
    // preserving the folder structure
    return gulp.src(staticFiles, { base: './' })
        .pipe(rename(path => path.dirname = path.dirname.replace('node_modules', '')))
        .pipe(gulp.dest('wwwroot/lib/'));
});