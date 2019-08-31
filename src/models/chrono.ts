/**
 * Utility class for creating a chrometer
 * @author Thiago Przyczynski <thiagocpp89@gmail.com>
 */
export class Chronometer {

    /**
     * Interval object
     */
    private interval: any;
  
    /**
     * Stores the seconds that have passed
     * @type {number}
     */
    private seconds: number = 0;
  
    /**
     * Time in digital format
     */
    public time: string = '00:00';
  
    public showSeconds: boolean = true;
  
    /**
     * Class constructor
     */
    constructor() {}
  
    /**
     * Starts the chronometer
     */
    start() {
      this.interval = window.setInterval(() => {
        this.seconds++;
        this.time = this.getTimeFormatted();
      }, 1000);
    }
  
    /**
     * Stops the chronometer
     */
    stop() {
      window.clearInterval(this.interval); // Clear the interval
      this.seconds = 0; // Sets seconds to zero
    }
  
    /**
     * Returns time formatted as HH:mm:ss
     * @returns {string}
     */
    getTimeFormatted() {
      var hours   = Math.floor(this.seconds / 3600);
      var minutes = Math.floor((this.seconds - (hours * 3600)) / 60);
      var seconds = this.seconds - (hours * 3600) - (minutes * 60);
  
      var hours_st = hours.toString();
      var minutes_st = minutes.toString();
      var seconds_st = seconds.toString();
      if (hours   < 10) {
        hours_st   = "0" + hours.toString();
      }
      if (minutes < 10) {
        minutes_st = "0" + minutes.toString();
      }
      if (seconds < 10) {
        seconds_st = "0" + seconds.toString();
      }
  
      var formatted_time = '';
      if (hours > 0) {
        formatted_time += hours_st + ':';
      }
      formatted_time += minutes_st;
      if (this.showSeconds) {
        formatted_time += ':' + seconds_st;
      }
      return formatted_time;
    }
}