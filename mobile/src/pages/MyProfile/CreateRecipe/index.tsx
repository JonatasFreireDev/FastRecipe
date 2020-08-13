import React from 'react';

import { StackScreenProps } from '@react-navigation/stack';
import { View, Text, Button } from 'react-native';
import { MyProfileStack } from '../../../interface/IRoutes';

const CreateRecipe: React.FC<StackScreenProps<
  MyProfileStack,
  'CreateRecipe'
>> = ({ navigation }) => {
  return (
    <>
      <View style={{ flex: 1, justifyContent: 'center', alignItems: 'center' }}>
        <Text> CreateRecipe</Text>
      </View>
    </>
  );
};

export default CreateRecipe;
