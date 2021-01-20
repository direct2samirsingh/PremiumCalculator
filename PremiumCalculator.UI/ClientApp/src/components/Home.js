import FormValidator from './FormValidator'
import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService';
import HomeModel from '../models/HomeModel';

export class Home extends Component {
    static displayName = Home.name;
    submitted = false;

    constructor(props) {
        super(props);
        this.state = {
            model: new HomeModel({}),
            serverErrors : []
        };

        this.calculate = this.calculate.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSelectChange = (field) => (e) => {
        
        let value = Array.from(e.target.selectedOptions, option => option.value);
        this.setState({ [field]: value[0] });
    }

    handleChange = (field) => (event) => {
        this.updateModel(field, event.target.value);        
    }

    handleSubmit(event) {
        this.populateData();
        event.preventDefault();
    }

    componentDidMount() {

        fetch('api/Occupation/GetSelectList')
            .then(response => {
                return response.json();
            }).then(data => {

                this.setState({
                    occupations: data,
                });
            });
    }

    render() {
        let result = this.state.loading
            ? <p><em>Calculating, please wait...</em></p>
            : this.state.monthlyPremium;

        let occupations = this.state.occupations || [];

        let optionItems = occupations.map((occupation) =>
            <option value={occupation.id} key={occupation.id}>{occupation.name}</option>
        );


        let errors = this.state.serverErrors;
        let errorItems = Object.keys(errors).map(name => (
            <p class="text-danger">{ errors[name] }</p>
        ));
        
        let submitted = this.submitted;
        let validation = this.state.model.validator.validate(this.state.model);
        
        return (
            <div>
                <h1>Enter details below:</h1>
                
                <form onSubmit={this.handleSubmit}>
                    <table>
                        <tbody>
                            <tr>
                                <td colSpan="2">
                                    {errorItems}
                                </td>
                            </tr>
                            <tr>
                                <td>Name</td>
                                <td><input required type="text" value={this.state.model.name} onChange={this.handleChange('name')} /></td>
                                <td>
                                    {submitted && validation.name.message !== '' && <span class="text-danger">{validation.name.message}</span>}
                                </td>
                            </tr>   
                            <tr>
                                <td>Age</td>
                                <td><input required type="number" value={this.state.model.age} onChange={this.handleChange('age')} /></td>
                                <td>{submitted && validation.age.message !== '' && <span class="text-danger">{validation.age.message}</span>}</td>
                            </tr>
                            <tr>
                                <td>Date of Birth</td>
                                <td><input required type="date" value={this.state.model.dateOfBirth} onChange={this.handleChange('dateOfBirth')} /></td>
                                <td>{submitted && validation.dateOfBirth.message !== '' && <span class="text-danger">{validation.dateOfBirth.message}</span>}</td>
                            </tr>
                            <tr>
                                <td>Death - Sum Insured</td>
                                <td><input required type="number" value={this.state.model.sumInsured} onChange={this.handleChange('sumInsured')} /></td>
                                <td>{submitted && validation.sumInsured.message !== '' && <span class="text-danger">{validation.sumInsured.message}</span>}</td>
                            </tr>
                            <tr>
                                <td>Occupation</td>
                                <td>
                                    <select required value={this.state.model.occupationId} onChange={this.handleChange('occupationId')}>
                                        {optionItems}
                                    </select>
                                </td>
                                <td>{submitted && validation.occupationId.message !== '' && <span class="text-danger">{validation.occupationId.message}</span>}</td>
                            </tr>
                            <tr>
                                <td>Monthly Premium</td>
                                <td>{result}</td>
                            </tr>
                        </tbody>
                    </table>
                </form>
                <br/>
                <button className="btn btn-primary" onClick={this.calculate}>Calculate</button>
            </div>
        );
    }


    async calculate() {
        const validation = this.state.model.validator.validate(this.state.model);
        this.setState({ validation });
        this.submitted = true;

        if (!validation.isValid) {
            return;
        }

        const token = await authService.getAccessToken();
        const requestObject = this.state.model;

        fetch('api/Premium', {
            method: 'POST',
            credentials: 'include',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify(requestObject)
        })
            .then(response => response.json())
            .then((data) => {
                this.setState({ monthlyPremium: data.monthlyPremium, serverErrors: data.errors, loading: false });
            })
            .catch(error => this.setState({
                isLoading: false,
                monthlyPremium: 0,
                serverErrors : ['', 'Error occured while processing ' + error]
            }));
    }

    updateModel(fieldName, fieldValue) {
        let model = { ...this.state.model };  // make a copy of the object first to avoid changes by reference      
        model[fieldName] = fieldValue; // use here event or value of selectedKey depending on your component's event
        this.setState({ model });

    }
}
