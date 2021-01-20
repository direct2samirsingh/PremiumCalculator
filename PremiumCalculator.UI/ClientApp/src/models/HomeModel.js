import FormValidator from '../components/FormValidator';

export default class HomeModel {
    constructor(model = {}) {
            
        this.name = model.name || '';
        this.age = model.age || '';
        this.dateOfBirth = model.dateOfBirth || '';
        this.sumInsured = model.sumInsured || '';
        this.occupationId = model.occupationId || 1;
        this.monthlyPremium = model.monthlyPremium || '';

        this.validator = new FormValidator([
            { field: 'name', method: 'isEmpty', validWhen: false, message: 'Please enter name.' },
            { field: 'age', method: 'isEmpty', validWhen: false, message: 'Please enter age.' },
            { field: 'age', method: 'isInt', args: [{ min: 1, max: 130 }], validWhen: true, message: 'Please enter age between 1-130.' },
            { field: 'dateOfBirth', method: 'isEmpty', validWhen: false, message: 'Please enter Date Of Birth.' },
            { field: 'dateOfBirth', method: this.isDateOfBirthInRange, validWhen: true, message: 'Date must be within past 130 years' },
            { field: 'sumInsured', method: 'isEmpty', validWhen: false, message: 'Please enter Sum Insured.' },
            { field: 'sumInsured', method: this.isValueGreaterThanZero, validWhen: true, message: 'Sum Insured must be greater than 0' },
            { field: 'occupationId', method: 'isEmpty', validWhen: false, message: 'Please select Occupation' }
        ]);
    }

    isDateOfBirthInRange = (inputvalue, state) => {
        
        var minDateAllowed = new Date();
        minDateAllowed.setFullYear(minDateAllowed.getFullYear() - 130);
        var maxDateAllowed = new Date();
        var inputDate = new Date(state.dateOfBirth);
        if (inputDate > maxDateAllowed || inputDate < minDateAllowed) {
            return false;
        }
        else {
            return true;
        }
    }

    isValueGreaterThanZero = (inputvalue, state) => {
        if (inputvalue > 0) {
            return true;
        }
        else {
            return false;
        }
    }
}


