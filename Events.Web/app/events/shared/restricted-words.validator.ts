import {FormControl } from '@angular/forms';
export function restrictedWords(words) {
    return (control: FormControl): { [key: string]: any } => {
        if (!words) return null;
        let invalidWords = words.map(m => control.value.toLowerCase().includes(m.toLowerCase()) ? m : null).filter(w => w != null);

        return invalidWords && invalidWords.length > 0 ? { 'restrictedWords': invalidWords.join(', ') } : null;
    };
}