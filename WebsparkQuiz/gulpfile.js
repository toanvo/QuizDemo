// JavaScript source code
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    runSequence = require("run-sequence"),
    sass = require("gulp-sass");

var paths = {
    webroot: "./wwwroot/"
};

paths.minJs = paths.webroot + "js/**/*.min.js";
paths.js = [paths.webroot + "js/services/*.js", paths.webroot + "js/controllers/*.js", paths.webroot + "js/services/app.js", "!" + paths.minJs];
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/main.min.js";
paths.concatCssDest = paths.webroot + "css/main.min.css";

gulp.task("sass", function () {
    return gulp.src('Styles/main.scss')
        .pipe(sass())
        .pipe(gulp.dest('wwwroot/css'));
});

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    return gulp.src(paths.js, { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task("default",
    function(cb) {
        return runSequence("clean", "sass", "min", cb);
    });

gulp.task("min", ["min:js", "min:css"]);