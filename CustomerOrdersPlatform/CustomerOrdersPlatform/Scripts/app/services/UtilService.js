angular.module('MyApp')
    .factory('UtilsService', [
    function () {
        return {
            
            getTimestamp: function(date){
                var d = new Date(date);
                var month = String((d.getMonth() + 1));
                var day = String(d.getDate());
                var year = d.getFullYear();
                var hours = d.getHours();
                var minutes = d.getMinutes();
                var ampm = hours >= 12 ? 'PM' : 'AM';
                hours = hours % 12;
                hours = hours ? hours : 12;
                minutes = minutes < 10 ? '0' + minutes : minutes;
                var strTime = hours + ':' + minutes + ' ' + ampm;
                if(month.length < 2){
                    month = '0' + month;
                }
                if(day.length < 2){
                    day = '0' + day;
                }
                var resultDate = [month, day, year].join('/') + ' ' + strTime;
                return resultDate;
            }
        };
    }]);
