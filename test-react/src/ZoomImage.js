/**
 * Created by Thao Nguyen on 07/13/2017.
 */
import React, {Component} from 'react';
import ReactDOM from 'react-dom';
import './ZoomImage.css';

class Thao extends Component {
    constructor(props) {
        super(props);
        this.state = {
            height: 200,
            width: 300
        }
    };

    render() {
        //console.log(this)
       // var {first, last, number, pic} = this.props;
        var {height} = this.state;

        return (
            <div className="div-center">
                <p>Thao Nguyen</p>

                <p><img src="https://unsplash.it/458/354" height={height}/></p>
                <p>
                    <button onClick={this.zoomPicIn.bind(this)}> +</button>
                    <button onClick={this.zoomPicOut.bind(this)}> -</button>
                </p>
            </div>
        );
    }

    zoomPicIn() {
        this.setState({height: this.state.height + 30});
    };

    zoomPicOut() {
        this.setState({height: this.state.height - 30});
    }
}

// ReactDOM.render(<Thao first="Thao" last="Nguyen" number="14" pic="https://unsplash.it/458/354"/>,
//     document.getElementById('test'));

export default Thao;