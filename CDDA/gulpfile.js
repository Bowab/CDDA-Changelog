'use strict';

var gulp = require('gulp');
var sass = require('gulp-sass');
var minify = require('gulp-minify');
var concat = require('gulp-concat');

//SASS
sass.compiler = require('node-sass');

gulp.task('sass', function () {
    return gulp.src('./sass/**/css.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('./wwwroot/css'));
});

gulp.task('minify-sass', function () {
    return gulp.src('./sass/**/css.scss')
        .pipe(sass({ outputStyle: 'compressed' }).on('error', sass.logError))
        .pipe(concat('css.min.css'))
        .pipe(gulp.dest('./wwwroot/css'));
});

gulp.task('sass:watch', function () {
    gulp.watch('./sass/**/*.scss', gulp.series('sass'));
    gulp.watch('./sass/**/*.scss', gulp.series('minify-sass'));
});

//JavaScript
gulp.task('minify-js', function () {
    return gulp.src('./scripts/*.js')
        .pipe(concat('app.js'))
        .pipe(minify())
        .pipe(gulp.dest('./wwwroot/js'));
});

gulp.task('js:watch', function () {
    gulp.watch('./scripts/*.js', gulp.series('minify-js'));
});

//All
gulp.task('all:watch', function () {
    gulp.watch('./scripts/*.js', gulp.series('minify-js'));
    gulp.watch('./sass/**/*.scss', gulp.series('sass'));
    gulp.watch('./sass/**/*.scss', gulp.series('minify-sass'));
});
