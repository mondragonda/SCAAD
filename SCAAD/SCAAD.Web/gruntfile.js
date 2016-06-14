module.exports = function (grunt) {
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-sass');
    grunt.loadNpmTasks('grunt-contrib-cssmin');

    grunt.initConfig({
        uglify: {
            my_target: {
                files: { 'wwwroot/app.js': ['Scripts/app.js', 'Scripts/**/*.js'] }
            }
        },

        sass: {
            dist: {
                options: {
                    style: 'expanded',
                    lineNumbers: true,
                    sourcemap: 'none'
                },
                files: [{
                    expand: true,
                    cwd: 'Styles/Sass',
                    src: ['**/*.scss'],
                    dest: 'Styles',
                    ext: '.css'
                }]
            }
        },
        
        cssmin: {
            my_target: {
                files: {
                    'wwwroot/style.css': ['Styles/main.css']
                }
            }
        },

        watch: {
            scripts: {
                files: ['Scripts/app.js', 'Scripts/**/*.js'],
                tasks: ['uglify']
            },
            sass: {
                files: ['Styles/Sass/**/*.scss'],
                tasks: ['sass', 'cssmin']
            }
        }
    });

    grunt.registerTask('default', ['uglify', 'sass', 'cssmin', 'watch']);
};